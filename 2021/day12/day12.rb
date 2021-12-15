# frozen_string_literal: true
require 'set'

sample = "start-A
start-b
A-c
A-b
b-d
A-end
b-end
"
class Cave
  attr_reader :name, :links
  def initialize(name)
    @name = name
    # should be other caves in here
    @links = []
  end
  def add_link(node)
    return if node.name == "start"
    return if self.name == "end"
    @links << node
  end
end

nodes = Set.new

sample.split("\n").each do |link|
  caves = link.split('-')
  node1 = nodes.select { |node| node.name == caves.first }.first
  node2 = nodes.select { |node| node.name == caves.last }.first

  node1 = Cave.new(caves.first) if node1.nil?
  node2 = Cave.new(caves.last) if node2.nil?

  node1.add_link(node2)
  node2.add_link(node1)

  nodes << node1
  nodes << node2
end

nodes.each do |node|
  derp = node.links.map do |n|
    n.name
  end
  puts "#{node.name} => #{derp}"
end

# recursive function goes here?
# we should have all of the links set up now?
# maybe a job for tomorrow :)

starting_node = nodes.select {|node| node.name == 'start'}

