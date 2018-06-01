using AbpHangfireConsole.Application.Services.HangfireMeta;
using AbpHangfireConsole.Application.Services.HangfireMeta.Dtos;
using AbpHangfireConsole.Hangfire.Framework;
using AbpHangfireConsole.Hangfire.Jobs.DocExtract.Dtos;
using Hangfire;
using Hangfire.Console;
using Hangfire.Server;
using System.Threading;

namespace AbpHangfireConsole.Hangfire.Jobs.DocExtract
{
    /// <summary>
    ///     Hangfire job to list the servers hangfire knows about directly from its database table Hangfire.Server
    /// </summary>
    public class DocExtractJob4GongZuoBiLu : HangfireJobBase<DocExtractParamsInput>
    {
        private readonly IHangfireMetaService _HangfireMetaService;

        public DocExtractJob4GongZuoBiLu(IHangfireMetaService aHangfireMetaService)
        {
            _HangfireMetaService = aHangfireMetaService;
        }
        [Queue("queue4")]
        /// <summary>
        ///     工作笔录
        /// </summary>
        /// <param name="aContext">Context of the job within HangFire.</param>
        /// <param name="aParams">Parameters for the job being executed.</param>
        public override void ExecuteJob(PerformContext aContext, DocExtractParamsInput aParams)
        {
            aContext.WriteProgressBar();
            aContext.WriteLine("工作笔录开始处理！");
            Thread.Sleep(1000);
            aContext.WriteProgressBar(50);
            Thread.Sleep(5000);
            aContext.WriteProgressBar(100);
            aContext.WriteLine("工作笔录处理完成");
        }
    }
}