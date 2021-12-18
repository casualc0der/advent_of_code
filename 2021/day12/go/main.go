package main

import (
	"fmt"
	"strings"
)

type nodes map[string][]string

var paths = [][]string{}

func main() {
	// sample := `start-A
	// start-b
	// A-c
	// A-b
	// b-d
	// A-end
	// b-end`

	question := `GC-zi
end-zv
lk-ca
lk-zi
GC-ky
zi-ca
end-FU
iv-FU
lk-iv
lk-FU
GC-end
ca-zv
lk-GC
GC-zv
start-iv
zv-QQ
ca-GC
ca-FU
iv-ca
start-lk
zv-FU
start-zi`

	input := strings.Split(question, "\n")
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

	answer := traverse(caves, []string{"start"}, "start")

	for _, p := range paths {
		fmt.Println(p)
	}
	fmt.Println(answer)
}

func traverse(c nodes, v []string, cu string) int {

	if cu == "end" {
		return 1
	}

	count := 0

	for _, node := range c[cu] {

		vv := v

		if isSmallCave(node) {
			if visited(vv, node) {
				continue
			} else {
				vv = append(vv, node)
			}
		}
		count += traverse(c, vv, node)
	}

	return count
}

func isSmallCave(cave string) bool {

	if strings.ToLower(cave) == cave {
		return true
	}
	return false

}

func visited(v []string, node string) bool {

	for _, n := range v {
		if n == node {
			return true
		}
	}
	return false
}
