package main

import (
	"fmt"
	"strconv"
	"strings"
)

func main() {

	sample := `1163751742
	1381373672
	2136511328
	3694931569
	7463417111
	1319128137
	1359912421
	3125421639
	1293138521
	2311944581`

	rawRows := strings.Split(sample, "\n")
	rows := []string{}

	for _, s := range rawRows {
		x := strings.TrimSpace(s)
		rows = append(rows, x)
	}
	y := len(rows)
	x := len(rows[0])
	input := [][]int{}

	// well done on the setup Eddie :D
	for i := 0; i < y; i++ {
		input = append(input, []int{})
		for j := 0; j < x; j++ {
			num, _ := strconv.Atoi(string(rows[i][j]))
			input[i] = append(input[i], num)
		}
	}

	answer := Dijkstra(input)
	fmt.Println(answer)
}

func Dijkstra(caves [][]int) int {
//	procedure BFS(G, root) is
//	let Q be a queue
//	label root as explored
//	Q.enqueue(root)
//	while Q is not empty do
//	v := Q.dequeue()
//	if v is the goal then
//	return v
//	for all edges from v to w in G.adjacentEdges(v) do
//		if w is not labeled as explored then
//	                  label w as explored
//	                  Q.enqueue(w)
//}
