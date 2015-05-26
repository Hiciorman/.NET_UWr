using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1._11
{
    class Program
    {
        static void Main( string[] args ) {
            // Create code compiler that generates code in memory (no executable)
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;
 
            // Create StringBuilder with user's code and append basic 'using' directives
            StringBuilder code = new StringBuilder();
            code.Append( "using System;\n" );
            code.Append( "using System.Text;\n" );
            code.Append( "namespace _3_1_11 {\n" );
 
            // Keep capturing code inputted by user into console
            // until the user types blank line
            Console.WriteLine("--- Type code here ---\n");
            string line;
            while ( (line = Console.ReadLine()) != "" ) {
                code.Append( line + "\n" );
            }
            code.Append( "}\n" );
 
            // Compile code provided by user
            CompilerResults results = codeProvider.CompileAssemblyFromSource( parameters, code.ToString() );
 
            // Check if there are any compile errors
            if ( results.Errors.Count > 0 ) {
                foreach ( CompilerError error in results.Errors ) {
                    Console.WriteLine( "Line: {0}, number: {1}", error.Line, error.ErrorNumber );
                    Console.WriteLine( "Error: " + error.ErrorText );
                }
                Console.WriteLine();
                return;
            }
            // Otherwise, execute the code
            try {
                Console.Write("Please specify the main class: ");
                string className = Console.ReadLine();
                Console.Write( "Please specify the main function to execute: " );
                string functionName = Console.ReadLine();
 
                var type = results.CompiledAssembly.GetType("_3_1_11." + className);
                var instance = Activator.CreateInstance( type );
                Console.WriteLine("\n--- Executed code ---\n");
                var output = type.GetMethod( functionName ).Invoke( instance, null );
            }
            catch ( Exception e ) {
                Console.WriteLine( "\n" + e.Message );
            }
 
            Console.ReadLine();
        }
    }
}
