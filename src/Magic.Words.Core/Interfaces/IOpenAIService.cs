using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Interfaces {
    public interface IOpenAIService {

        Task<string> CompleteSentence(string text);
        Task<string> CompleteSentenceAdvance(string text);

        Task<string> CheckProgramingLanguage(string language);
    }
}
