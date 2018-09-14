//using System;
//using EventFlow.Logs;
//using Xunit.Abstractions;

//namespace Simulator.Tests
//{
//    public sealed class TestLogAdapter : Log
//    {
//        private readonly ITestOutputHelper output;

//        public TestLogAdapter(ITestOutputHelper output)
//        {
//            this.output = output;
//        }

//        protected override bool IsDebugEnabled => false;

//        protected override bool IsInformationEnabled => true;

//        protected override bool IsVerboseEnabled => false;

//        protected override void Write(LogLevel logLevel, string format, params object[] args)
//        {
//            if (args.Length == 0)
//            {
//                this.output.WriteLine(format);
//            }
//            else
//            {
//                this.output.WriteLine(format, args);
//            }
//        }

//        protected override void Write(LogLevel logLevel, Exception exception, string format, params object[] args)
//        {
//            if (args.Length == 0)
//            {
//                this.output.WriteLine(format);
//            }
//            else
//            {
//                this.output.WriteLine(format, args);
//            }
//        }
//    }
//}