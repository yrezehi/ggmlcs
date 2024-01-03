using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGML
{

    public unsafe delegate void FreeBuffer(GGMLBackendBufferT buffer);
    public unsafe delegate void* GetBase(GGMLBackendBufferT buffer);
    public unsafe delegate void InitTensor(GGMLBackendBufferT buffer, ggml_tensor* tensor);
    public unsafe delegate void SetTensor(GGMLBackendBufferT buffer, ggml_tensor* tensor, void* data, UIntPtr offset, UIntPtr size);
    public unsafe delegate void GetTensor(GGMLBackendBufferT buffer, ggml_tensor* tensor, void* data, UIntPtr offset, UIntPtr size);
    public unsafe delegate void CpyTensorFrom(GGMLBackendBufferT buffer, ggml_tensor* src, ggml_tensor* dst);
    public unsafe delegate void CpyTensorTo(GGMLBackendBufferT buffer, ggml_tensor* src, ggml_tensor* dst);
    public unsafe delegate void Clear(GGMLBackendBufferT buffer, byte value);
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGMLBackendBufferI
    {
        public FreeBuffer free_buffer;
        public GetBase get_base;
        public InitTensor init_tensor;
        public SetTensor set_tensor;
        public GetTensor get_tensor;
        public CpyTensorFrom cpy_tensor_from;
        public CpyTensorTo cpy_tensor_to;
        public Clear clear;
    }
}
