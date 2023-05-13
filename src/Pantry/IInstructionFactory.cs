namespace Pantry;

public interface IInstructionFactory
{
    TInstruction Create<TInstruction>(string name) where TInstruction : Instruction;
}

public interface IInstructionFactory<out TInstruction> where TInstruction : Instruction
{
    TInstruction Create(string name);
}