using JoberMQ.Library.Dbos;
using JoberMQ.Library.Models;
using JoberMQ.Library.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoberMQ.Library.Helpers
{
    public class DboCreatorHelper
    {
        public static JobDbo Job(JobTransportModel builder)
        {
            var jobDbo = new JobDbo();
            jobDbo.JobDetails = new List<JobDetailDbo>();

            jobDbo.Id = Guid.NewGuid();
            jobDbo.Operation = builder.Operation;
            jobDbo.Producer = new ProducerModel
            {
                ClientKey = builder.ClientInfo.ClientKey
            };
            jobDbo.Info = builder.Info;
            jobDbo.Publisher = builder.Publisher;
            jobDbo.Timing = builder.Timing;
            jobDbo.IsJobResultMessage = builder.IsResult;
            jobDbo.JobResultMessage = builder.ResultMessage;
            jobDbo.Status = new StatusModel
            {
                IsCompleted = false,
                IsError= false,
                StatusTypeMessage = Enums.Status.StatusTypeMessageEnum.None,
                TempAgainDate = null
            };

            foreach (var item in builder.MultipleMessages)
            {
                jobDbo.JobDetails.Add(new JobDetailDbo
                {
                    Id = Guid.NewGuid(),
                    Message = item.Message,
                    IsResultMessage = item.IsResult,
                    ResultMessage = item.ResultMessage
                });
            }

            return jobDbo;
        }

        public static MessageDbo Message(JobTransportModel builder)
        {
            var messageDbo = new MessageDbo();

            messageDbo.Id = Guid.NewGuid();
            messageDbo.Operation = builder.Operation;
            messageDbo.Producer = new Library.Models.ProducerModel
            {
                ClientKey = builder.ClientInfo.ClientKey
            };
            messageDbo.Message = builder.MultipleMessages.FirstOrDefault().Message;
            messageDbo.IsResult = builder.IsResult;
            messageDbo.ResultMessage = builder.MultipleMessages.FirstOrDefault().ResultMessage;
            messageDbo.TriggerGroupsId = builder.Timing.TriggerGroupsId;

            messageDbo.Status = new StatusModel
            {
                IsCompleted = false,
                IsError= false,
                StatusTypeMessage = Enums.Status.StatusTypeMessageEnum.None,
                TempAgainDate = null
            };

            //toto kontrol
            //messageDbo.Consuming = new Library.Models.ConsumingModel
            //{
            //    ClientKey = "client 1"
            //    //ıonoınıonıonıo
            //};


            return messageDbo;
        }

    }
}
