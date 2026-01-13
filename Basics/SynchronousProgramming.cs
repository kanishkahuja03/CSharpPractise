using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Threading;

namespace WarehouseOrderProcessing
{
    class Program
    {
        //LOGGING
        static void Log(string message)
        {
            Console.WriteLine(
                $"{DateTime.Now} " +
                $"[Thread {Thread.CurrentThread.ManagedThreadId}] " +
                message);
        }

        //ORDER COUNTER
        static int _totalOrders = 0;
        static readonly object _orderCounterLock = new object();

        //ORDER QUEUE (MONITOR)
        static readonly Queue<int> _orderQueue = new Queue<int>();
        static readonly object _queueLock = new object();

        //PAYMENT GATEWAY (MUTEX)
        static readonly Mutex _paymentMutex =
            new Mutex(false, "Global\\PAYMENT_GATEWAY_MUTEX");

        //DATABASE CONNECTIONS (SEMAPHORE)
        static readonly Semaphore _dbSemaphore = new Semaphore(3, 3);

        //REPORT GENERATION (SEMAPHORESLIM)
        static readonly SemaphoreSlim _reportSemaphore = new SemaphoreSlim(2, 2);

        static bool _shutdown = false;

        static void Main()
        {
            Log("System starting");

            new Thread(Producer).Start();

            for (int i = 0; i < 6; i++)
            {
                new Thread(Worker).Start();
            }

            Console.ReadLine();
            _shutdown = true;
        }

        //PRODUCER
        static void Producer()
        {
            int orderId = 1;

            while (!_shutdown && orderId<=2)
            {
                lock (_queueLock)
                {
                    _orderQueue.Enqueue(orderId);
                    Log($"Order {orderId} ENQUEUED");
                    Monitor.Pulse(_queueLock);
                }

                orderId++;
                Thread.Sleep(300); // simulate incoming orders
            }
        }

        //WORKER
        static void Worker()
        {
            while (!_shutdown)
            {
                int orderId;

                // WAIT FOR ORDER
                lock (_queueLock)
                {
                    while (_orderQueue.Count == 0)
                    {
                        Log("Queue empty — WAITING");
                        Monitor.Wait(_queueLock);
                        Log("Resumed from queue WAIT");
                    }

                    orderId = _orderQueue.Dequeue();
                    Log($"Order {orderId} DEQUEUED");
                }

                ProcessOrder(orderId);
            }
        }

        //ORDER PROCESSING
        static void ProcessOrder(int orderId)
        {
            // PAYMENT MUTEX
            Log("Waiting for PAYMENT MUTEX");
            _paymentMutex.WaitOne();
            try
            {
                Log("PAYMENT MUTEX ACQUIRED");
                Thread.Sleep(200);
            }
            finally
            {
                _paymentMutex.ReleaseMutex();
                Log("PAYMENT MUTEX RELEASED");
            }

            // DATABASE
            Log("Waiting for DB CONNECTION");
            _dbSemaphore.WaitOne();
            try
            {
                Log("DB CONNECTION ACQUIRED");
                Thread.Sleep(300);
            }
            finally
            {
                _dbSemaphore.Release();
                Log("DB CONNECTION RELEASED");
            }

            // ORDER COUNTER
            lock (_orderCounterLock)
            {
                _totalOrders++;
                Log($"Order counter updated {_totalOrders}");
            }

            // OPTIONAL REPORT
            if (orderId % 2 == 0)
            {
                GenerateReport(orderId);
            }
        }

        //REPORT GENERATION
        static void GenerateReport(int orderId)
        {
            Log("Waiting for REPORT SLOT");
            _reportSemaphore.Wait();
            try
            {
                Log($"REPORT GENERATION STARTED for order {orderId}");
                Thread.Sleep(500);
            }
            finally
            {
                _reportSemaphore.Release();
                Log($"REPORT GENERATION FINISHED for order {orderId}");
            }
        }
    }
}

