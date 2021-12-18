package main

import (
	"fmt"
	"strings"
)

type nodes map[string][]string

var paths = [][]string{}

func main() {
	sample := `start-A
start-b
A-c
A-b
b-d
A-end
b-end`

	// this will make a dictionary of the caves
	input := strings.Split(sample, "\n")
	caves := make(nodes)
	for _, edge := range input {
		raw := strings.Split(edge, "-")
		caves[raw[0]] = []string{}
		caves[raw[1]] = []string{}
	}
	for _, edge := range input {
		raw := strings.Split(edge, "-")
		if raw[0] != "start" && raw[1] != "end" {
			caves[raw[1]] = append(caves[raw[1]], raw[0])

		}
		caves[raw[0]] = append(caves[raw[0]], raw[1])
	}

	fmt.Println(caves)

	for _, cave := range caves["start"] {

		traverse(caves, []string{"start"}, cave)

	}

	for _, p := range paths {

		fmt.Println(p)
	}
}

func traverse(c nodes, v []string, cu string) bool {
	if visited(v, cu) {
		return false
	}

	if cu == "end" {
		v = append(v, "end")
		paths = append(paths, v)

		return true
	}

	v = append(v, cu)

	for _, node := range c[cu] {
		if !visited(v, node) {
			return traverse(c, v, node)
		}
	}

	return false
}

func visited(v []string, node string) bool {

	if strings.ToUpper(node) == node {
		return false
	}

	for _, n := range v {
		if n == node {
			return true
		}
	}

	return false
}

func pathCompletedBefore(v []string) bool {

	for _, p := range paths {

		fmt.Println(v)
		fmt.Println(p)
		if len(v) == len(p) {
			return true
		}

	}
	return false
}
