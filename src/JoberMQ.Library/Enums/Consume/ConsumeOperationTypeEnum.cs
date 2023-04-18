namespace JoberMQ.Library.Enums.Consume
{
    public enum ConsumeOperationTypeEnum
    {
        SpecialAdd = 1,
        SpecialRemove = 2,

        GroupAdd = 3,
        GroupRemove = 4,

        QueueAdd = 5,
        QueueRemove = 6,

        EventSubscript = 7,
        EventUnSubscript = 8,
    }
}
