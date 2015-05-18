namespace Gears.LMAX
{
    using System;

    using Amazon.Kinesis.Model;

    using Disruptor;

    public class KinesisRecordHandler : IEventHandler<Record>
    {
        public void OnNext(Record data, long sequence, bool endOfBatch)
        {
            Console.WriteLine("Handled event #{0}", sequence);
        }
    }
}