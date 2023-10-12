﻿using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UdemyToolkit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CWController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> LogTest(string cityName)
        {
            return Ok("All Ok!!");

        }

        private static async Task LogUsingClint(string message)
        {
            var logClient = new AmazonCloudWatchLogsClient();
            var logGroupName = "/aws/cloudwatch-test-app";
            var logStreamName = $"Data_Insertion_{Guid.NewGuid()}"; //DateTime.UtcNow.ToString("yyyyMMddHHssfff");

            var existing = await logClient.DescribeLogGroupsAsync(new DescribeLogGroupsRequest()
            {
                LogGroupNamePrefix = logGroupName
            });

            var logGroupExists = existing.LogGroups.Any(x => x.LogGroupName == logGroupName);

            if (!logGroupExists)
            {
                await logClient.CreateLogGroupAsync(new CreateLogGroupRequest(logGroupName));
            }

            await logClient.CreateLogStreamAsync(new CreateLogStreamRequest(logGroupName, logStreamName));
            await logClient.PutLogEventsAsync(new PutLogEventsRequest
            {
                LogGroupName = logGroupName,
                LogStreamName = logStreamName,
                LogEvents = new List<InputLogEvent>
                {
                    new InputLogEvent
                    {
                        Message = $"{message}",
                        Timestamp = DateTime.UtcNow,
                    }
                }
            });
        }

    }
}
