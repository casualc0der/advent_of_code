package main

import (
	"fmt"
	"math"
	"os"
	"strings"
)

func main() {

	pairInsertionRule := map[string]string{}

	// sample := `NNCB

	// CH -> B
	// HH -> N
	// CB -> H
	// NH -> C
	// HB -> C
	// HC -> B
	// HN -> C
	// NN -> C
	// BH -> H
	// NC -> B
	// NB -> B
	// BN -> B
	// BB -> N
	// BC -> B
	// CC -> N
	// CN -> C`

	input, _ := os.ReadFile("input14.txt")

	// sample question
	// raw := strings.Split(sample, "\n\n")
	// question 1
	raw := strings.Split(string(input), "\n\n")

	sequence := strings.TrimSpace(raw[0])
	rawDictionary := strings.Split(strings.TrimSpace(raw[1]), "\n")

	for _, line := range rawDictionary {

		l := strings.Split(line, " -> ")
		pairInsertionRule[l[0]] = l[1]

	}

	// question 1
	question1(sequence, pairInsertionRule)
	// question 2
	question2(sequence, pairInsertionRule)

}

func question1(sequence string, rules map[string]string) {
	for i := 0; i < 10; i++ {
		var tempSequence string
		for j := 0; j < len(sequence)-1; j++ {

			key := string(sequence[j]) + string(sequence[j+1])
			str := string(sequence[j]) + rules[key] + string(sequence[j+1])
			tempSequence = strings.TrimSuffix(tempSequence, string(sequence[j]))
			tempSequence += str

		}
		sequence = tempSequence
	}
	ans1 := countElements(sequence)

	fmt.Printf("The answer to question 1 is: %d\n", ans1)

}

func question2(seq string, rules map[string]string) {
	// how can we speed this up?
	// find all the elements and then merge into array?

	sequence := strings.Split(seq, "")

	for i := 0; i < 20; i++ {
		tempSequence := []string{}

		for j := 0; j < len(sequence)-1; j++ {

			key := string(sequence[j]) + string(sequence[j+1])
			tempSequence = append(tempSequence, rules[key])

		}

		// ok so we have the array of the sequence now we need to merge?

		// merge has to happen before this!

		sequence = merge(sequence, tempSequence)
		fmt.Println(len(sequence))
	}
	// ans2 := countElements(sequence)

	// fmt.Printf("The answer to question 2 is: %d\n", ans2)

}

// this is very slow
func merge(keep []string, merge []string) []string {

	for i := range merge {

		keep = append(keep[:i+1], keep[i:]...)
	}
	for i, derp := range merge {
		keep[i] = derp
	}

	return keep

}

func countElements(sequence string) int {

	elements := map[string]int{}

	for _, element := range sequence {
		if _, ok := elements[string(element)]; ok {
			elements[string(element)]++
		} else {
			elements[string(element)] = 1
		}
	}

	// find min/max
	min := math.MaxInt32
	max := math.MinInt32
	for _, v := range elements {

		if v < min {
			min = v
		}
		if v > max {
			max = v
		}
	}
	return max - min

}
