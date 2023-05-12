using Microsoft.Extensions.DependencyInjection;

namespace Pantry.Core.Instructions;

public class InstructionFactory : IInstructionFactory
{
    private readonly IServiceProvider _serviceProvider;

    public InstructionFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TInstruction Create<TInstruction>(string name) where TInstruction : Instruction
    {
        var factory = _serviceProvider.GetRequiredService<IInstructionFactory<TInstruction>>();
        return factory.Create(name);
    }
}