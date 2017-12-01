using System;

namespace nIt.nCommon.nExecution
{
    public abstract class AbstractExecutionUnit : IExecutionUnit
    {
        Func<bool> _oxisAllowedFunc;


        protected virtual void __BeforeExecution()
        {
            this._ThrowIfDisabled(!this._IsExternallyAllowed);
            this.IsExecuting = true;
        }


        protected virtual void __AfterExecution()
        {
            this.IsExecuting = false;
        }



        public AbstractExecutionUnit(string commandName, Func<bool> isAllowedObservable)
        {
            this.CommandName = commandName;
            _oxisAllowedFunc = isAllowedObservable;
        }

        protected bool _IsExternallyAllowed 
            => _oxisAllowedFunc.Invoke();


        public bool CanExecute { get { return this._IsExternallyAllowed && !this.IsExecuting; } }

        public bool IsExecuting { get; protected set; }

        public string CommandName { get; private set; }




    }




}
