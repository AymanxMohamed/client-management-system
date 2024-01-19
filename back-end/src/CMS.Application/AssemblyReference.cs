using System.Reflection;

namespace CMS.Application;

public class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}