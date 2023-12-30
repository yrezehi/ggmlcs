#!/bin/bash

GREEN_TEXT_COLOR='\e[32m'
BLUE_TEXT_COLOR='\e[34m'
RESET_TEXT_COLOR='\e[0m'

BOLD_TEXT_FORMAT='\e[1m'
RESET_TEXT_FORMAT='\e[0m'

display_help() {
    echo
    echo "Usage: ./build [option...] [params...]" >&2
    echo
}

colorful() {
    echo -e "${BLUE_TEXT_COLOR}$1${RESET_TEXT_COLOR}"
}

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
        colorful "\n[$1]\n"
        return 1;
    fi
	colorful "\n[$1]\n"
	# execute the command without the first parameter
	${@:2}
}

build_llama() {        
	if ! [ -x "$(command -v cmake)" ]; then
	  print_instruction "FAILED" echo "Error: cmake is not installed"
	  exit 1
	fi
	# build llama.cpp
	( cd $llama_project_directory/build && cmake -DBUILD_SHARED_LIBS=ON -DLLAMA_BLAS=ON -DLLAMA_BLAS_VENDOR=OpenBLAS .. && cmake --build . --config $build_type )
}

post_llama_build() {
    cp "$llama_project_directory/build/bin/$build_type/llama.dll" $dll_output_dictionary
}

root_directory="$( cd "$(dirname "$0")" >/dev/null 2>&1 ; pwd -P )"

build_type="Debug"

print_instruction "WORKING DIRECTORY" echo "$root_directory"
 
build_directory="$root_directory/build"

if [ -d "$build_directory" ]; then
	rm -rf $build_directory
fi

llama_project_directory=$root_directory/ggmlcs/llama.cpp

print_instruction "RE/CREATE BUILD DIRECTORY"

spinning_process mkdir $build_directory

print_instruction "BUILD DIRECTORY" echo "$build_directory"

print_instruction "BUILD LLAMA.CPP PROJECT"

build_llama

print_instruction "POST BUILD LLAMA.CPP PROJECT"

dll_output_dictionary=$root_directory/ggmlcs/ggmlcs/Native/Runtimes/windows

post_llama_build

print_instruction "ALL GOOD"
