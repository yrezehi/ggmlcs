using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGML
{

    public delegate IntPtr GetName(GGMLBackend backend);
    public delegate void Free(GGMLBackend backend);
    public delegate GGMLBackendBufferTypeT GetDefaultBufferType(GGMLBackend backend);
    public delegate void SetTensorAsync(GGMLBackend backend, GGMLTensor tensor, IntPtr data, IntPtr offset, IntPtr size);
    public delegate void GetTensorAsync(GGMLBackend backend, GGMLTensor tensor, IntPtr data, IntPtr offset, IntPtr size);
    public delegate void CpyTensorFromAsync(GGMLBackend backend, GGMLTensor src, GGMLTensor dst);
    public delegate void CpyTensorToAsync(GGMLBackend backend, GGMLTensor src, GGMLTensor dst);
    public delegate void Synchronize(GGMLBackend backend);
    public delegate GGMLBackendGraphPlanT GraphPlanCreate(GGMLBackend backend, GGMLCGraph cgraph);
    public delegate void GraphPlanFree(GGMLBackend backend, GGMLBackendGraphPlanT plan);
    public delegate void GraphPlanCompute(GGMLBackend backend, GGMLBackendGraphPlanT plan);
    public delegate void GraphCompute(GGMLBackend backend, GGMLCGraph cgraph);
    public delegate bool SupportsOp(GGMLBackend backend, GGMLTensor op);

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGMLBackendI
    {
        public GetName get_name;

        public Free free;

        public GetDefaultBufferType get_default_buffer_type;

        public SetTensorAsync set_tensor_async;
        public GetTensorAsync get_tensor_async;

        public CpyTensorFromAsync cpy_tensor_from_async;
        public CpyTensorToAsync cpy_tensor_to_async;

        public Synchronize synchronize;

        public GraphPlanCreate graph_plan_create;
        public GraphPlanFree graph_plan_free;
        public GraphPlanCompute graph_plan_compute;

        public GraphCompute graph_compute;

        public SupportsOp supports_op;
    }
}
