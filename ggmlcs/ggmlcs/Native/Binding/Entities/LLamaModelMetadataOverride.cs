using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native.Binding.Entities
{
    public delegate void LlamaProgressCallback(float progress, IntPtr ctx);
}
