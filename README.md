## LIBRARY MANAGEMENT SYSTEM

## STEPS

Creation of the Multi Tier Library and App

- Model Library
- Data Access Library
- Bisness Layer Library
- Presentation Layer App


## INSTALLATION

- dotnet add package Microsoft.EntityFrameworkCore
- dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
- dotnet add package Microsoft.EntityFrameworkCore.Tools
- dotnet add package Microsoft.EntityFrameworkCore.Design

Ensure All The Packages are of same version to void any of the conflicts or any kind of errors

## CREATE THE ER DIAGRAM

<img width="1198" height="2423" alt="image" src="https://github.com/user-attachments/assets/b8d636c9-829e-4ec4-a58b-e3e0680a6c64" />


The Model Library is created with master and the normal tables

Master Tables

- BookStatus (available,unavailable,lost,damaged)
- BorrowingStatus (borrowed,returned,overdue)
- DamagedLevel (little,medium,hard) - include the default cost for each level of damage and the cost is fetched from here
- FineCategory (overdue,lost,damaged)
- MemberType (only for the user role)(basic,premium,student)
- Payment Method (Differnet method of payment) (cod,upi,cards)
- Role (So For 2 Roles are created) (Admin,User)

Normal Tables

- BookCategory
- Book
- BookISBN
- BookCopy
- Borrowing
- Fine
- DamagedBook
- Payment
- Member

## Book

For The Book Initially the book table contains the very common details such as booktitle,bookauthor,category.

For Each editon published year the ISBN number will be changed so created the separate Table for the ISBN Book conating the book id to link between the book and book isbn

Each Book with some ISBN Number can have different copies

The physical details of the book that is included in the book status is found in book copy

Each Book Copy Will have unique copy number

The borrowing of book is mainly handled in book copy as it mention the physical data of the book.

## Borrowing

While Borrowing the needed requirments are checked and the only data are inserted into the table

Done Using the procedure in the database

If any error it raise exception and rollback

## Returning

The admin can check the book and update the book status

as lost,damaged for internal fine calculation

## Fine

While Returning the Book The return date will be updated

The Fine will be automatically genereted usinf functions and the date they submit and inserted into the fine table

This return is handled in procedure while returning the book

Only borrow id is needed for it

The fine can be of three types

- overdue
- lost
- damaged

The usage of both lost and overdue is also implemented

The fine amount are listed in the tables

## DamagedBook

It include the person who damaged the book,which book etc

It helps to maintain the records of the person who are responsible for damaging the book often and can deactivate the member

## Payment

The fine amount can be paid by the user

No need to pay fully

As per their needed they can split and pay

The Data will be updated

Example - 500 rupees can be paid and 100,200,200 in any days and in any amount

The reflection will happen in the backend



<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/657aba9d-aeb8-4c0d-8820-2e7d4810f079" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/eaa4f1ee-76b5-47d8-8df7-48e53dd1be22" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/1d0fd808-5203-4d73-bfe5-1789aa3c1ed5" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/e391cb1b-29bd-4b51-a2e7-75cded04cb9e" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d9446ee1-ab03-45ee-b019-d6f77421d915" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/868bdf92-9692-485f-86f7-44acfc2adf83" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/20b540ab-84ce-4619-87ea-ae4364780fb0" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d687d902-60ca-4a20-bc29-f5f34da5d936" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/bd8f7e87-e5df-4e5e-9f70-be43734415fd" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/e049d4c7-29dc-4ebc-808d-213728704836" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d8062048-5d51-41b1-9128-96c582d1d4a4" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/74b81c77-1476-4ba6-92f3-0786d3677c88" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/41be8340-e469-4b9e-ac74-aca0da8c56dc" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/2ac16a45-6636-4958-9b90-f3f37724afb5" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/7ae0aa6d-a9e8-463c-809a-1cc249b1bf78" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/6e479cc3-d741-4c1f-85cb-2686ba64c5af" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/23434517-9f5d-4a99-85e2-63b16f7ec5ef" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/1b377160-88ba-43f9-a3cb-27e5e02e02c5" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/c8268a94-20f2-4282-9755-1014d6ef2dff" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/74434c2c-d945-4282-bdac-832406d447fe" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/cf14561e-1933-4407-9271-1642524562ed" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/00de0f09-3b03-4d8c-8989-8f7af8352e8a" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/06083a7d-cac7-4ed0-b087-ad8713240776" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/7996b6ad-14b4-4f55-845b-65cd2409a738" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/08cf82a9-de3c-4ef3-9bf5-2b79585726b5" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/16765218-70f4-4292-bb8f-c6fe67a2b671" />



<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/36068117-87f6-494a-ad96-a119878d6fdf" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/b37a9a06-c750-4029-9e4c-760432b23b52" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/4b8c08e4-4b54-44a0-9bd2-895156fd0a4a" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d7710d71-e75d-4e1e-9f5e-1b49b256a4c6" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/ac4b9609-1b19-42c7-bbfa-a250f9aa6a7a" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/77c7e003-88f3-4c19-b733-4fd37d1faa29" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/206b5396-0fb9-4f0e-b10d-a2681fc280b0" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/a5548989-023a-4887-baea-a3fb6e9bf821" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/75b45782-6449-41fd-893a-5f151086b7bb" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/91dff07e-1f4b-44e9-8ba8-54d6576abcb0" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/7534f8d3-fb60-4274-b4e8-9ed125fa7060" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/b8a01dc8-3f4a-488e-aa48-b1843a9228f1" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/03bbfcc8-8aa0-40a1-81a1-9955ba2ef715" />


<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/39d6f5c6-03c6-44f5-9166-ba098cba8720" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/9eda2918-e02e-4834-b818-1f201d0910fb" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/ed3848e0-24f0-4481-abb4-1e351a5e9430" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/f8521122-b20b-4589-80f5-a673efca25b7" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/9f060b8f-5c77-4e7f-aa99-4832ab481b8f" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/bc674c5e-d342-4ca1-a887-825418f7c294" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/4febe335-0bfb-4991-9d9f-95cd0f87f53f" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/0daf1132-57a1-4917-b98c-4001aa4abc95" />

