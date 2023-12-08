#!/bin/bash

spinning_process() {
    if [[ -z "$@" ]]; then
        echo -e "no process was provided for function $FUNCNAME!";
        return 1;
    fi
    $@ 1> /dev/null 2> /dev/null & PID=$!
    printf "["
    while kill -0 $PID 2> /dev/null; do
        printf  "▓";
        sleep 1;
    done
    printf "] done!\n"
}

print_instruction() {
    if [[ "$#" -eq 1 ]]; then
        echo -e "\n[$1]\n"
        return 1;
    fi
	echo -e "\n[$1]\n"
	# execute the command without the first parameter
	${@:2}
}

# expects cwd to be llama.cpp/build

build_llama_cpp() {        
	if ! [ -x "$(command -v cmake)" ]; then
	  print_instruction "FAILED" echo "Error: cmake is not installed"
	  exit 1
	fi
	# build llama.cpp
	cmake -DBUILD_SHARED_LIBS=ON .. && cmake --build .
}


# copies libllama to build folder
# copies convert-pth-to-ggml.py to build folder
# copies quantize.exe to build
# copies quantize.py to build
pre_llama_cpp_build() {
	echo "not finished!"
}

root_directory="$( cd "$(dirname "$0")" >/dev/null 2>&1 ; pwd -P )"

print_instruction "WORKING DIRECTORY" echo "$root_directory"
 
build_directory="$root_directory/build"

if [ -d "$build_directory" ]; then
	rm -rf $build_directory
fi

print_instruction "RE/CREATE BUILD DIRECTORY"

spinning_process mkdir $build_directory

print_instruction "BUILD DIRECTORY" echo "$build_directory"
  
echo -e "\n[BUILD FINISHED]"