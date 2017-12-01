using System;

namespace nIt.nCommon.nExecution
{
    public class SynchAction<TInput> : AbstractExecutionUnit, ISynchAction<TInput>
    {

        Action<TInput> _oxBodyAction;


        public SynchAction(Action<TInput> oxBodyAction, Func<bool> isAllowedFunc, string commandName)
            : base(commandName, isAllowedFunc)
        {
            _oxBodyAction = oxBodyAction;
        }


        protected void _Execute(TInput input)
        {
            _oxBodyAction(input);
        }


        public virtual void Execute(TInput input)
        {
            __BeforeExecution();

            try
            {
                _Execute(input);
            }
            finally
            {

                __AfterExecution();
            }
        }

 
    }
}
