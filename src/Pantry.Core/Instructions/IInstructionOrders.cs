namespace Pantry.Core.Instructions;

public interface IInstructionOrders
{
    IInstructionOrders After(string name);
    IInstructionOrders Before(string name);
}