class Puzzle
  def self.solve(file)

    question_1(file)
    question_2(file)

  end

  def self.question_1(file)

    gamma = ""
    epsilon = ""
    digits = Array.new(12, 0)
    file.each do |binary|
      12.times do |i|
        digits[i]+=1 if binary[i] == '1'
        digits[i]-=1 if binary[i] == '0'
      end
    end

    digits.each do |d|
      if d < 0
        gamma << '0'
        epsilon << '1'
      else
        gamma << '1'
        epsilon << '0'
      end
    end
    p gamma.to_i(2) * epsilon.to_i(2)

  end

  def self.question_2(file)
    sigma = file

    i = 0
    until sigma.size == 1 do
      temp = []
      zero = 0
      one = 0
      sigma.each do |binary|
        zero += 1 if binary[i] == '0'
        one += 1 if binary[i] == '1'
      end

      temp = if one >= zero
               sigma.select { |x| x[i] == '1' }
             else
               sigma.select { |x| x[i] == '0' }
             end
      sigma = temp
      i += 1
    end

    omega = file

    i = 0
    until omega.size == 1 do
      temp = []
      zero = 0
      one = 0
      omega.each do |binary|
        zero += 1 if binary[i] == '0'
        one += 1 if binary[i] == '1'
      end

      temp = if zero <= one
               omega.select { |x| x[i] == '0' }
             else
               omega.select { |x| x[i] == '1' }
             end
      omega = temp
      i += 1
    end

    p sigma.first.to_i(2) * omega.first.to_i(2)

  end
end

class Opener
  def self.file(path)
    File.read(path).split
  end
end

file = Opener.file("input3.txt")
Puzzle.solve(file)
