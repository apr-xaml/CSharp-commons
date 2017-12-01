namespace nIt.nCommon.nExecution
{
    public interface ISynchAction<TInput> : IExecutionUnit
    {
        void Execute(TInput input);
    }
}
