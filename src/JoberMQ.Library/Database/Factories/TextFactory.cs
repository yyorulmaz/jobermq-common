using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Database.Enums;
using JoberMQ.Library.Database.Models;
using JoberMQ.Library.Database.Repository.Abstraction.Text;
using JoberMQ.Library.Database.Repository.Implementation.Text.Default;

namespace JoberMQ.Library.Database.Factories
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
