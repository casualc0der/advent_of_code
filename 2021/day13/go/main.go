package main

import (
	"fmt"
	"os"
	"strconv"
	"strings"
)

type coord struct {
	y int
	x int
}

type fold struct {
	direction string
	line      int
}

func main() {
	question, _ := os.ReadFile("input13.txt")

	dots := []coord{}
	folds := []fold{}

	raw := strings.Split(string(question), "\n\n")
	f := strings.Split(raw[0], "\n")
	i := strings.Split(raw[1], "\n")

	for _, ff := range f {
		fo := strings.Split(ff, ",")

		y, _ := strconv.Atoi(fo[1])
		x, _ := strconv.Atoi(fo[0])

		dots = append(dots, coord{
			y: y,
			x: x,
		})
	}

	for _, ii := range i {
		io := strings.Split(ii, "fold along ")
		if len(io) > 1 {

			iv := strings.Split(io[1], "=")
			line, _ := strconv.Atoi(iv[1])

			folds = append(folds, fold{
				direction: iv[0],
				line:      line,
			})
		}
	}

	for _, fold := range folds {
		if fold.direction == "y" {
			tempDots := []coord{}
			for _, dot := range dots {
				if dot.y > fold.line {
					jo := fold.line - (dot.y - fold.line)
					tempDots = append(tempDots, coord{
						y: jo,
						x: dot.x,
					})
				} else {
					tempDots = append(tempDots, dot)
				}
			}
			dots = tempDots
		}
		if fold.direction == "x" {
			tempDots := []coord{}
			for _, dot := range dots {
				if dot.x > fold.line {
					my := maxX(dots) - dot.x
					tempDots = append(tempDots, coord{
						y: dot.y,
						x: my,
					})
				} else {
					tempDots = append(tempDots, dot)
				}
			}
			dots = tempDots
		}
	}
	printDots(dots)

}

func maxY(dots []coord) int {

	max := -1
	for _, dot := range dots {
		if dot.y > max {
			max = dot.y
		}
	}
	return max
}

func maxX(dots []coord) int {

	max := -1
	for _, dot := range dots {
		if dot.x > max {
			max = dot.x
		}
	}
	return max
}

func printDots(dots []coord) {

	maxY := maxY(dots)
	maxX := maxX(dots)

	answer := [][]string{}

	for i := 0; i <= maxY; i++ {
		answer = append(answer, []string{})
		for j := 0; j <= maxX; j++ {
			answer[i] = append(answer[i], " ")
		}
	}

	for _, dot := range dots {
		answer[dot.y][dot.x] = "x"
	}

	for _, a := range answer {
		fmt.Println(a)
	}
}
