using JoberMQ.Common.Database.Base;
using JoberMQ.Common.Database.Enums;
using JoberMQ.Common.Database.Models;
using JoberMQ.Common.Database.Repository.Abstraction.Text;
using JoberMQ.Common.Database.Repository.Implementation.Text.Default;

namespace JoberMQ.Common.Database.Factories
{
    public class TextFactory
    {
        public static ITextRepository<TValue> Create<TValue>(TextFactoryEnum textFactory, TextFileConfigModel textFileConfig)
            where TValue : DboPropertyGuidBase, new()
        {
            ITextRepository<TValue> textRepository;

            switch (textFactory)
            {
                case TextFactoryEnum.Default:
                    textRepository = new DfTextRepository<TValue>(textFileConfig);
                    break;
                default:
                    textRepository = new DfTextRepository<TValue>(textFileConfig);
                    break;
            }

            return textRepository;
        }
    }
}
