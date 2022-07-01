#ifndef EasyNode_h
#define EasyNode_h

#include "declNLinkedList.h"

#define NEW_PRIMITIVENODE(n, T) typedef PrimitiveNode<T> n

template <typename T>
class PrimitiveNode : public Node<PrimitiveNode<T>>
{
public:
	PrimitiveNode();
	PrimitiveNode(T&);
	PrimitiveNode(T&&);

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