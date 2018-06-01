using AbpHangfireConsole.Hangfire.Framework;

namespace AbpHangfireConsole.Hangfire.Jobs.DocExtract.Dtos
{
    public class DocExtractParamsInput : HangfireParamsInputBase
    {
        public int CaseNo { get; set; }
    }
}