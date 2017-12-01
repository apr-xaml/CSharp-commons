using System;

namespace nIt.nCommon.nExecution
{
    public interface IExecutionUnit
    {
        string CommandName { get; }
        bool IsExecuting { get; }

        bool CanExecute { get; }

    }



    static internal class ext_IExecutionUnit
    {
        static InvalidOperationException _GetIsDisabledException(this IExecutionUnit _this)
        {
            return new InvalidOperationException("Command is disabled and thus cannot be executed, Name = {0}".Form(_this.CommandName));
        }

        static InvalidOperationException _GetIsExecutingException(this IExecutionUnit _this)
        {
            return new InvalidOperationException("Command is already executing, Name = {0}".Form(_this.CommandName));
        }

        static internal void _ThrowIfDisabled(this IExecutionUnit _this, bool isDisabled)
        {
            if (isDisabled)
            {
                var precondNotMetExc = _this._GetIsDisabledException();
                throw precondNotMetExc;
            }

            if (_this.IsExecuting)
            {
                var isExecutingExc = _this._GetIsExecutingException();
                throw isExecutingExc;
            }
        }
    }
}
