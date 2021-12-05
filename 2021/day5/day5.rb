class Line
  def initialize(args)
    @x1 = args[0]
    @y1 = args[1]
    @x2 = args[2]
    @y2 = args[3]
  end

  def horizontal?
    @x1 == @x2
  end
  def vertical?
    @y1 == @y2
  end
  def diagonal?
    !horizontal? && !vertical?
  end

  attr_reader :x1, :y1, :x2, :y2
end

lines = []
# needs to be multiarray
vents = Array.new(1000) { Array.new(1000,0)}

input = File.readlines('/Users/eddsansome/code/advent_of_code/day5/input5.txt')
# input = <<~BEGIN
# 0,9 -> 5,9
# 8,0 -> 0,8
# 9,4 -> 3,4
# 2,2 -> 2,1
# 7,0 -> 7,4
# 6,4 -> 2,0
# 0,9 -> 2,9
# 3,4 -> 1,4
# 0,0 -> 8,8
# 5,5 -> 8,2
# BEGIN

input.each do |i|
  tmp = i.gsub(' -> ', ',')
  line = tmp.split(',').map(&:to_i)
  lines << Line.new(line)
end

lines.each do |line|
  if line.horizontal?
    derp = [line.y1, line.y2].sort
    derp.first.upto(derp.last) do |num|
      vents[line.x1][num]+=1
    end
  end

  if line.vertical?
    derp = [line.x1, line.x2].sort
    derp.first.upto(derp.last) do |num|
      vents[num][line.y1]+=1
    end
  end

  if line.diagonal?
    x = [line.x1, line.x2].sort
    y = [line.y1, line.y2].sort

    xo = (x.first..x.last).to_a
    yo = (y.first..y.last).to_a

    if line.x1 < line.x2
      xo.reverse!
    end
    if line.y1 < line.y2
      yo.reverse!
    end

    derp = xo.zip(yo)

    derp.each do |coord|
      p coord
      vents[coord.first][coord.last]+=1
    end

  end
end

puts lines.size
vents.transpose.each do |v|
  p v
end
p vents.flatten.select {|x| x > 1}.size