namespace CodeCamp.Async.Example1
{
    public static class FirstExample
    {
        public static void Execute()
        {
            //SyncExample();
            AsyncExample();
        }

        private static void SyncExample()
        {
            var obj = new SyncObject();
            obj.DoSyncThing();
        }

        private static void AsyncExample()
        {
            var obj = new AsyncObject();
            obj.DoAsyncThingSynchronously();
            //obj.DoAsyncThingTheRightWay();
        }
    }
}
