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