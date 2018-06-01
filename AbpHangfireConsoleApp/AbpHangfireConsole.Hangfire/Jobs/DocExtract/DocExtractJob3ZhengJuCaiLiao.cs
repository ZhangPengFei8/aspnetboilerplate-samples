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
    public class DocExtractJob3ZhengJuCaiLiao : HangfireJobBase<DocExtractParamsInput>
    {
        private readonly IHangfireMetaService _HangfireMetaService;

        public DocExtractJob3ZhengJuCaiLiao(IHangfireMetaService aHangfireMetaService)
        {
            _HangfireMetaService = aHangfireMetaService;
        }
        [Queue("queue3")]
        /// <summary>
        ///     证据材料
        /// </summary>
        /// <param name="aContext">Context of the job within HangFire.</param>
        /// <param name="aParams">Parameters for the job being executed.</param>
        public override void ExecuteJob(PerformContext aContext, DocExtractParamsInput aParams)
        {
            aContext.WriteProgressBar();
            aContext.WriteLine("证据材料开始处理！");
            Thread.Sleep(1000);
            aContext.WriteProgressBar(50);
            Thread.Sleep(5000);
            aContext.WriteProgressBar(100);
            aContext.WriteLine("证据材料处理完成");
        }
    }
}