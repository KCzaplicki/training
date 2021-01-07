using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAutoFixture
{
    public class CustomParserWrapper : ICustomParser
    {
        private readonly ICustomParser customParser;

        public CustomParserWrapper(ICustomParser customParser)
        {
            this.customParser = customParser;
        }

        public string Parse(DataModel dataModel) => $"{nameof(DataModel)}: [{customParser.Parse(dataModel)}]";
    }
}
