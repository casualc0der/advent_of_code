package main

import (
	"fmt"
	"strings"
)

func main() {

	pairInsertionRule := map[string]string{}

	sample := `NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C`

	raw := strings.Split(sample, "\n\n")

	sequence := raw[0]
	rawDictionary := strings.Split(raw[1], "\n")

	for _, line := range rawDictionary {

		l := strings.Split(line, " -> ")
		pairInsertionRule[l[0]] = l[1]

	}

	for i := 0; i < 1; i++ {
		var tempSequence string
		for j := 0; j < len(sequence)-1; j++ {

			key := string(sequence[j]) + string(sequence[j+1])
			str := string(sequence[j]) + pairInsertionRule[key]
			tempSequence += str

		}
		sequence = tempSequence
	}
	fmt.Println(sequence)

}
