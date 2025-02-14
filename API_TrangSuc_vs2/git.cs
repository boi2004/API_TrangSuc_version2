/*
1. Kiểm tra danh sách các nhánh hiện có
bash
Sao chép
Chỉnh sửa
git branch
Lệnh này hiển thị danh sách các nhánh hiện có và đánh dấu (*) nhánh hiện tại.

2. Tạo một nhánh mới
bash
Sao chép
Chỉnh sửa
git branch ten-nhanh-moi
Thay ten-nhanh-moi bằng tên bạn muốn đặt.

3. Chuyển sang nhánh mới
bash
Sao chép
Chỉnh sửa
git checkout ten-nhanh-moi
Hoặc dùng lệnh gọn hơn:

bash
Sao chép
Chỉnh sửa
git switch ten-nhanh-moi
4. Tạo và chuyển ngay sang nhánh mới
Nếu bạn muốn tạo nhánh mới và chuyển ngay vào đó, dùng:

bash
Sao chép
Chỉnh sửa
git checkout -b ten-nhanh-moi
Hoặc:

bash
Sao chép
Chỉnh sửa
git switch -c ten-nhanh-moi
5. Đẩy nhánh mới lên remote
Nếu bạn làm việc với repository từ xa (GitHub, GitLab, Bitbucket, ...), hãy đẩy nhánh mới lên server:

bash
Sao chép
Chỉnh sửa
git push -u origin ten-nhanh-moi
Lệnh này giúp đồng bộ nhánh mới với repository trên remote.

6. Hợp nhất (merge) nhánh vào main
Sau khi hoàn tất công việc trên nhánh mới, bạn có thể quay lại nhánh chính và gộp nó vào:

bash
Sao chép
Chỉnh sửa
git checkout main  # Hoặc git switch main
git merge ten-nhanh-moi
7. Xóa nhánh (nếu không cần nữa)
Xóa nhánh cục bộ:

bash
Sao chép
Chỉnh sửa
git branch -d ten-nhanh-moi
Nếu nhánh chưa được merge, dùng -D để xóa bắt buộc:

bash
Sao chép
Chỉnh sửa
git branch -D ten-nhanh-moi
Xóa nhánh trên remote:

bash
Sao chép
Chỉnh sửa
git push origin --delete ten-nhanh-moi */