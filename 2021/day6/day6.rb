# input = "3,4,3,1,2";

input = File.readlines("/Users/eddsansome/code/advent_of_code/2021/day6/dotnet/input5.txt").first
# var input = await File.ReadAllTextAsync("/Users/eddsansome/code/advent_of_code/2021/day6/dotnet/input5.txt");

# lets tidy this up

fishes = input.split(",").map(&:to_i)

DERP = {
  0 => 0,
  1 => 0,
  2 => 0,
  3 => 0,
  4 => 0,
  5 => 0,
  6 => 0,
  7 => 0,
  8 => 0,
}

def fish_tally(fish)
  tally = DERP.dup
  fish.each do |f|
    tally[f] += 1
  end
  tally
end

def fishies(days, fish)
  if days == 0
    total = 0
    return fish.values.sum
    # total goes here of the values
  end

  respawns = 0;
  new_tally = DERP.dup

  0.upto(8) do |i|
    if i == 0
      respawns = fish[i]
      new_tally[0] = 0
    else
      new_tally[i - 1] = fish[i]
    end

  end

  new_tally[6] += respawns
  new_tally[8] += respawns

  return fishies(days - 1, new_tally)

end

p fishies(80, fish_tally(fishes))
p fishies(256, fish_tally(fishes))



