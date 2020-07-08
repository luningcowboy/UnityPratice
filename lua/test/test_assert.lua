--assert(a, 'a 没有声明')
a = 1
--a = 2
assert(a == 1, 'a 不等于 1')
