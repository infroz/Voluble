using System.Diagnostics.CodeAnalysis;
using System.Text;
using Voluble.Exceptions;

namespace Voluble;

public class VolubleScope : IDisposable
{
    internal List<Failure> Failures = [];
    
    [ThreadStatic] private static VolubleScope? _current;
    private static bool isInScope => _current is not null;

    private static VolubleScope? _old;

    public VolubleScope()
    {
        _old = _current;
        _current = this;
    }
  
    internal static void FailWith(string message)
    {
        if (_current is null)
            throw new Failure(message);
        
        _current.Failures.Add(new Failure(message));
    }


    public void Dispose()
    {
        GC.SuppressFinalize(this);
        
        if (Failures.Count > 0)
        {
            var message = new StringBuilder();
            
            message.AppendLine("One or more failures occurred during the scope:");
            foreach (var failure in Failures)
                message.AppendLine(failure.Message);
            
            throw new FailureCollection(Failures, message.ToString());
        }
        
        _current = _old;
    }
}