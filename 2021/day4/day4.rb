class BingoNumber
  def initialize(num)
    @num = num
    @marked = false
  end

  def mark
    @marked = true
  end

  def marked?
    @marked
  end

  attr_reader :marked, :num

end

class BingoCard
  attr_reader :rows, :columns
  def initialize(raw, name)
    @tracking = true
    @raw = raw.split("\n")
    @name = name
    @rows = []
    @columns = Array.new(5, [])
  end

  def stop_tracking
    @tracking = false
  end

  def mark(num)
    return unless @tracking
    @rows.each do |row|
      row.each do |r|
        if r.num == num
          r.mark
        end
      end
    end
  end

  def winner?
    return unless @tracking
    @rows.each do |row|
      return true if row.all? {|r| r.marked? }
    end

    @columns.each do |col|
      return true if col.all? {|c| c.marked? }
    end
    false
  end

  def all_unmarked
    @rows.map do |row|
      unmarked = row.reject {|r| r.marked?}
      unmarked.map {|u| u.num }.sum
    end.sum
  end

  def create_rows
    @raw.each do |row|
      @rows << row.split.map {|r| BingoNumber.new(r.to_i)}
    end
  end
  def create_columns
    @columns = @rows.transpose
  end
end



input = File.readlines("input4.txt")

# grab the bingo numbers
bingo_caller = input.shift.split(",").map(&:to_i)
# remove the first entry that is a newline
input.shift
# create bingo cards - each entry is a string seperated by newlines
# these are our rows
cards = input.join.split("\n\n")

i = 1
formatted_cards = cards.map do |card|
  b = BingoCard.new(card, "card: #{i}")
  i += 1
  b.create_rows
  b.create_columns
  b
end

def part_1(bc, fc)
bc.each do |num|
  fc.each do |card|
    card.mark(num)
    if card.winner?
      return card.all_unmarked * num
    end
  end
end
end

def part_2(bc, fc)
  bc.each do |num|
    fc.delete_if do |card|
      card.mark(num)
      if card.winner? && fc.size == 1
        return fc.first.all_unmarked * num
      end
      card.winner? && fc.size > 1
    end
  end
end

p part_1(bingo_caller, formatted_cards)
p part_2(bingo_caller, formatted_cards)




