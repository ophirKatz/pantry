namespace Pantry.Execution;

public interface IInstructionExecutor<in TInstruction> where TInstruction : Instruction
{
    Task<ExecutionResult> ExecuteAsync(TInstruction instruction, ExecutionContext context, CancellationToken cancellationToken = default);
}