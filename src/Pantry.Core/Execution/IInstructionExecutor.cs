using Pantry.Core.Instructions;

namespace Pantry.Core.Execution;

public interface IInstructionExecutor<in TInstruction> where TInstruction : Instruction
{
    Task<ExecutionResult> ExecuteAsync(TInstruction instruction, ExecutionContext context, CancellationToken cancellationToken = default);
}