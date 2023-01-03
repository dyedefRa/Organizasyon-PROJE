﻿using Hangfire;
using Microsoft.Extensions.Options;
using Organizasyon.HangfireServices.Abstract;
using Organizasyon.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizasyon.HangfireServices.Concrete
{
    public class RecurringJobService : IRecurringJobService
    {
        private readonly DefaultSettings _defaultSettings;

        public RecurringJobService(
            IOptions<DefaultSettings> defaultSettings)
        {
            _defaultSettings = defaultSettings.Value;
        }

        #region Numune Üretim Mail Job

        public async Task<bool> SendProductionMailsJob()
        {
            RecurringJob.AddOrUpdate("NumuneUretimBildirimMailJob", () => SendProductionMailsInit(), "*/" + _defaultSettings.AutoResendExpressionMinute + " * * * *", System.TimeZoneInfo.Local);
            return await Task.FromResult(true);
        }

        [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        [DisableConcurrentExecution(timeoutInSeconds: 10 * 60)]
        public async Task SendProductionMailsInit()
        {
            if (_defaultSettings.UseJobs)
            {

            }
                //await _productAppService.AutoSenderServiceAndMailAsync();
        }

        #endregion
    }
}
