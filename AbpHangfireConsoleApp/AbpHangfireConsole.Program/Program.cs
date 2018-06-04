using System;
using System.Threading;
using AbpHangfireConsole.Hangfire.Jobs.DocExtract;
using AbpHangfireConsole.Hangfire.Jobs.DocExtract.Dtos;
using AbpHangfireConsole.Hangfire.Jobs.GetServers;
using AbpHangfireConsole.Hangfire.Jobs.GetServers.Dtos;
using Hangfire;
using Microsoft.Owin.Hosting;

namespace AbpHangfireConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AbpHangfireConsoleApplication<AbpHangfireConsoleProgramModule> application = new AbpHangfireConsoleApplication<AbpHangfireConsoleProgramModule>();

            try
            {
                application.Application_Start();

                using (WebApp.Start<Startup>("http://127.0.0.1:8111"))
                {
                    Console.WriteLine("Hangfire Server started on http://127.0.0.1:8111/hangfire");
                    Console.WriteLine("");
                    Console.WriteLine("In 10s the job GetServersJob will execute.");
                    Console.WriteLine("");
                    //Kick off a sample job for 10 seconds from now
                    //BackgroundJob.Schedule<GetServersJob>(x => x.ExecuteJob(null, new GetServersParamsInput()), TimeSpan.FromSeconds(10));
                    //Console.WriteLine("Wait for the job to execute. Otherwise press any key to terminate....");
                    //SimpleTest(100);
                    DocExtract(10);
                    Console.ReadKey();
                }
            }
            finally
            {
                application.Application_End();
            }
            
        }
        static void DocExtract(int caseNumber)
        {
            var client = new BackgroundJobClient();
            //var jobId = client.Enqueue(() => SomeMethod(0));
            var jobId1 = client.Enqueue<DocExtractJob1QiSuZhuang>(x=>x.ExecuteJob(null,new DocExtractParamsInput() { CaseNo=0}));
            var jobId2 = client.Enqueue<DocExtractJob2DaBianZhuang>(x => x.ExecuteJob(null, new DocExtractParamsInput() { CaseNo = 0 }));
            var jobId3 = client.Enqueue<DocExtractJob3ZhengJuCaiLiao>(x => x.ExecuteJob(null, new DocExtractParamsInput() { CaseNo = 0 }));
            var jobId4 = client.Enqueue<DocExtractJob4GongZuoBiLu>(x => x.ExecuteJob(null, new DocExtractParamsInput() { CaseNo = 0 }));
            for (int caseNo=1; caseNo < caseNumber; caseNo++)
            {
                jobId1 = client.ContinueWith<DocExtractJob1QiSuZhuang>(jobId1,x=>x.ExecuteJob(null, new DocExtractParamsInput() { CaseNo = caseNo }));
                jobId2 = client.ContinueWith<DocExtractJob2DaBianZhuang>(jobId1, x => x.ExecuteJob(null, new DocExtractParamsInput() { CaseNo = caseNo }));
                jobId3 = client.ContinueWith<DocExtractJob3ZhengJuCaiLiao>(jobId1, x => x.ExecuteJob(null, new DocExtractParamsInput() { CaseNo = caseNo }));
                jobId4 = client.ContinueWith<DocExtractJob4GongZuoBiLu>(jobId1, x => x.ExecuteJob(null, new DocExtractParamsInput() { CaseNo = caseNo }));
            }

        }
        /// <summary>
        /// 简单测试
        /// </summary>
        static void SimpleTest(int counter)
        {
            var client = new BackgroundJobClient();
            var jobId = client.Enqueue(() => SomeMethod(0));
            var jobId1 = client.Enqueue(() => SomeMethod1(0));
            var jobId2 = client.Enqueue(() => SomeMethod2(0));
            var jobId3 = client.Enqueue(() => SomeMethod3(0));
            var jobId4 = client.Enqueue(() => SomeMethod4(0));
            var jobId5 = client.Enqueue(() => SomeMethod5(0));
            var jobId6 = client.Enqueue(() => SomeMethod6(0));
            var jobId7 = client.Enqueue(() => SomeMethod7(0));
            var jobId8 = client.Enqueue(() => SomeMethod8(0));
            var jobId9 = client.Enqueue(() => SomeMethod9(0));
            for (int i = 1; i < counter; i++)
            {
                jobId = client.ContinueWith(jobId, () => SomeMethod(i));
                //Thread.Sleep(1000);
                jobId1 = client.ContinueWith(jobId1, () => SomeMethod1(i));
                jobId2 = client.ContinueWith(jobId2, () => SomeMethod2(i));
                //jobId3 = client.ContinueWith(jobId3, () => SomeMethod3(i));
                client.Enqueue(() => SomeMethod3(i));
                jobId4 = client.ContinueWith(jobId4, () => SomeMethod4(i));
                jobId5 = client.ContinueWith(jobId5, () => SomeMethod5(i));
                jobId6 = client.ContinueWith(jobId6, () => SomeMethod6(i));
                jobId7 = client.ContinueWith(jobId7, () => SomeMethod7(i));
                jobId8 = client.ContinueWith(jobId8, () => SomeMethod8(i));
                jobId9 = client.ContinueWith(jobId9, () => SomeMethod9(i));

            }
        }
        [Queue("queue9")]
        public static void SomeMethod9(int i)
        {
            Console.WriteLine(i + ":某案件9");
        }
        [Queue("queue8")]
        public static void SomeMethod8(int i)
        {
            Console.WriteLine(i + ":某案件8");
        }
        [Queue("queue7")]
        public static void SomeMethod7(int i)
        {
            Console.WriteLine(i + ":某案件7");
        }
        [Queue("queue6")]
        public static void SomeMethod6(int i)
        {
            Console.WriteLine(i + ":某案件6");
        }
        [Queue("queue5")]
        public static void SomeMethod5(int i)
        {
            Console.WriteLine(i + ":某案件5");
        }
        [Queue("queue4")]
        public static void SomeMethod4(int i)
        {
            Console.WriteLine(i + ":某案件4");
        }
        public static void SomeMethod(int i)
        {
            Console.WriteLine(i.ToString() + ":某案件default");
        }
        [Queue("queue1")]
        public static void SomeMethod1(int i)
        {
            Console.WriteLine(i + ":某案件1");

        }
        [Queue("queue2")]
        public static void SomeMethod2(int i)
        {
            Console.WriteLine(i + ":某案件2");

        }
        [Queue("queue3")]
        public static void SomeMethod3(int i)
        {
            Thread.Sleep(10000);
            Console.WriteLine(i + ":某案件3a");
            //Thread.Sleep(5000);
            //Console.WriteLine(i + ":某案件3b");
        }
    }
}
