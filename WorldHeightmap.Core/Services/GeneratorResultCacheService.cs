using System;
using System.Collections.Generic;
using System.Text;

using WorldHeightmap.Core.Models;

namespace WorldHeightmap.Core.Services
{
    public class GeneratorResultCacheService
    {
        private GeneratorResult Result { get; set; }

        public GeneratorResult GetResult()
        {
            return Result;
        }

        public void SetResult(GeneratorResult result)
        {
            Result = result;
        }
    }
}
