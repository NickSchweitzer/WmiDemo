using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TheCodingMonkey.WmiDemo.Common
{
    /// <summary>Custom Collection class for parsing different forms of command line arguments.</summary>
    /// <remarks>Based on code by Richard Lopes
    /// http://www.codeproject.com/KB/recipes/command_line.aspx</remarks>
    public class CmdLineArguments : Dictionary<string, string>
    {
        public CmdLineArguments(string[] Args)
        {
            Regex Spliter = new Regex(@"^-{1,2}|^/|=|:", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Regex Remover = new Regex(@"^['""]?(.*?)['""]?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            string Parameter = null;
            string[] Parts;

            // Valid parameters forms:
            // {-,/,--}param{ ,=,:}((",')value(",'))
            // Examples: -param1 value1 --param2 /param3:"Test-:-work" /param4=happy -param5 '--=nice=--'
            foreach (string Txt in Args)
            {
                // Look for new parameters (-,/ or --) and a possible enclosed value (=,:)
                Parts = Spliter.Split(Txt, 3);
                switch (Parts.Length)
                {
                    // Found a value (for the last parameter found (space separator))
                    case 1:

                        if (Parameter != null)
                        {
                            if (!ContainsKey(Parameter))
                            {
                                Parts[0] = Remover.Replace(Parts[0], "$1");
                                Add(Parameter, Parts[0]);
                            }
                            Parameter = null;
                        }

                        // else Error: no parameter waiting for a value (skipped)
                        break;

                    // Found just a parameter
                    case 2:

                        // The last parameter is still waiting. With no value, set it to true.
                        if (Parameter != null)
                        {
                            if (!ContainsKey(Parameter))
                                Add(Parameter, "true");
                        }

                        Parameter = Parts[1];
                        break;

                    // Parameter with enclosed value
                    case 3:

                        // The last parameter is still waiting. With no value, set it to true.
                        if (Parameter != null)
                        {
                            if (!ContainsKey(Parameter))
                                Add(Parameter, "true");
                        }

                        Parameter = Parts[1];

                        // Remove possible enclosing characters (",')
                        if (!ContainsKey(Parameter))
                        {
                            Parts[2] = Remover.Replace(Parts[2], "$1");
                            Add(Parameter, Parts[2]);
                        }

                        Parameter = null;
                        break;
                }
            }

            // In case a parameter is still waiting
            if (Parameter != null)
            {
                if (!ContainsKey(Parameter))
                    Add(Parameter, "true");
            }
        }

        public bool GetBoolean(string key)
        {
            if (!ContainsKey(key))
                return false;

            bool isBool = false;
            bool returnVal = bool.TryParse(this[key], out isBool);
            if (isBool)
                return returnVal;
            else
                return false;
        }
    }
}