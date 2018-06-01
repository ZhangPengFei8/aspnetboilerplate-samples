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
    public class DocExtractJob1QiSuZhuang : HangfireJobBase<DocExtractParamsInput>
    {
        private readonly IHangfireMetaService _HangfireMetaService;

        public DocExtractJob1QiSuZhuang(IHangfireMetaService aHangfireMetaService)
        {
            _HangfireMetaService = aHangfireMetaService;
        }
        [Queue("queue1")]
        /// <summary>
        ///     起诉状
        /// </summary>
        /// <param name="aContext">Context of the job within HangFire.</param>
        /// <param name="aParams">Parameters for the job being executed.</param>
        public override void ExecuteJob(PerformContext aContext, DocExtractParamsInput aParams)
        {
            aContext.WriteProgressBar();
            aContext.WriteLine("起诉状文书开始处理！");
            Thread.Sleep(1000);
            aContext.WriteProgressBar(50);
            Thread.Sleep(5000);
            aContext.WriteProgressBar(100);
            aContext.WriteLine("起诉状文书处理完成！");
        }
    }
}