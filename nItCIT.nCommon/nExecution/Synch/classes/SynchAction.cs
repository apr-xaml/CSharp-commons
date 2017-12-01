using System;

namespace nIt.nCommon.nExecution
{
    public class SynchAction : AbstractExecutionUnit, ISynchAction
    {

        Action _oxAction;


        public SynchAction(Action oxAction, Func<bool> oxIsAllowedFunc, string commandName)
            : base(commandName, oxIsAllowedFunc)
        {
            _oxAction = oxAction;
        }

        protected void __Execute()
        {
            _oxAction();
        }

        public virtual void Execute()
        {

            __BeforeExecution();

            try
            {
                __Execute();
            }
            finally
            {

                __AfterExecution();
            }
        }


    }
}
