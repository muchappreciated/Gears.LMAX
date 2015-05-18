using System.Threading.Tasks;

namespace Gears.LMAX
{
    using Amazon.Kinesis.Model;

    using Disruptor.Dsl;

    internal class Program
    {
        private static void Main(string[] args)
        {
            const int RingBufferSize = 1024;
            var disruptor = new Disruptor<Record>(() => new Record(), RingBufferSize, TaskScheduler.Default);

            disruptor.HandleEventsWith(new KinesisRecordHandler());

            var ringBuffer = disruptor.Start();

            while (true)
            {

                var batchedRecords = ringBuffer.NewBatchDescriptor(100);

                ringBuffer.Next(batchedRecords);

                ringBuffer.Publish(batchedRecords);
            }
        }
    }
}