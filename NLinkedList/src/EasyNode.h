#ifndef EasyNode_h
#define EasyNode_h

#include "declNLinkedList.h"

#define NEW_EASYNODE(n, T) typedef EasyNode<T> n

template <typename T>
class EasyNode : public Node<EasyNode<T>>
{
public:
	EasyNode();
	EasyNode(T&);
	EasyNode(T&&);

	T& get() const;
	void set(T&);
	void set(T&&);

	operator T& () const;

	void operator=(T&);
	void operator=(T&&);
private:
	mutable T data;
};

#endif