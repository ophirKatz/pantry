namespace Pantry;

public interface IInstructionOrders
{
    IInstructionOrders After(string name);
    IInstructionOrders Before(string name);
}